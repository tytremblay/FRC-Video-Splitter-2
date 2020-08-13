using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace FRCVideoSplitter2
{
    class YouTubeApi
    {
        internal class VideoUploader
        {
            UserCredential credential;
            Assembly _assembly;

            /// <summary>
            /// Set the credentials using the application's client secrets.
            /// </summary>
            /// <returns></returns>
            public async Task SetCredentials()
            {
                _assembly = Assembly.GetExecutingAssembly();
                var stream = _assembly.GetManifestResourceStream("FRCVideoSplitter2.client_secrets.json");
                using (stream) // new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        // This OAuth 2.0 access scope allows for full read/write access to the
                        // authenticated user's account.
                        new[] { YouTubeService.Scope.Youtube },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(this.GetType().ToString())
                        );
                }
            }

            /// <summary>
            /// Creates a playlist on the user's channel 
            /// </summary>
            /// <param name="name">Name of the playlist</param>
            /// <param name="description">Description of the playlist.</param>
            /// <returns></returns>
            public String CreatePlaylist(String name, String description, bool isPrivate)
            {
                if (credential == null)
                {
                    return null;
                }

                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = this.GetType().ToString()
                });

                // Create a new, private playlist in the authorized user's channel.
                var newPlaylist = new Playlist();
                newPlaylist.Snippet = new PlaylistSnippet();
                newPlaylist.Snippet.Title = name;
                newPlaylist.Snippet.Description = description;
                newPlaylist.Status = new PlaylistStatus();
                if (isPrivate)
                {
                    newPlaylist.Status.PrivacyStatus = "private";
                }
                else
                {
                    newPlaylist.Status.PrivacyStatus = "public";
                }
                newPlaylist = youtubeService.Playlists.Insert(newPlaylist, "snippet,status").Execute();

                return newPlaylist.Id;
            }

            /// <summary>
            /// Adds a given video to a given playlist
            /// </summary>
            /// <param name="playlistId">YouTube ID of the playlist</param>
            /// <param name="videoId">YouTube ID of the video</param>
            public void AddToPlaylist(String playlistId, String videoId)
            {
                if (credential == null)
                {
                    return;
                }

                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = this.GetType().ToString()
                });

                var newPlaylistItem = new PlaylistItem();
                newPlaylistItem.Snippet = new PlaylistItemSnippet();
                newPlaylistItem.Snippet.PlaylistId = playlistId;
                newPlaylistItem.Snippet.ResourceId = new ResourceId();
                newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
                newPlaylistItem.Snippet.ResourceId.VideoId = videoId;
                newPlaylistItem = youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").Execute();
            }

            /// <summary>
            /// Gets a list of playlists for the set credentials.
            /// </summary>
            /// <returns></returns>
            public List<Playlist> GetPlaylists()
            {
                if (credential == null)
                {
                    return null;
                }

                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = this.GetType().ToString()
                });

                var channelsListRequest = youtubeService.Channels.List("contentDetails");
                channelsListRequest.Mine = true;

                // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
                var channelsListResponse = channelsListRequest.Execute();

                var channel = channelsListResponse.Items[0];

                var playlistListRequest = youtubeService.Playlists.List("snippet");
                playlistListRequest.ChannelId = channel.Id;
                return playlistListRequest.Execute().Items as List<Playlist>;
            }

            /// <summary>
            /// Get a list of items in the playlist for the given credentials and playlist id.
            /// </summary>
            /// <param name="playlistId"></param>
            /// <returns></returns>
            public List<PlaylistItem> GetItemsInPlaylist(string playlistId)
            {
                if (credential == null)
                {
                    return null;
                }

                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = this.GetType().ToString()
                });

                var channelsListRequest = youtubeService.Channels.List("contentDetails");
                channelsListRequest.Mine = true;

                // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
                var channelsListResponse = channelsListRequest.Execute();

                var channel = channelsListResponse.Items[0];

                var playlistListItemsRequest = youtubeService.PlaylistItems.List("snippet");
                playlistListItemsRequest.PlaylistId = playlistId;
                return playlistListItemsRequest.Execute().Items as List<PlaylistItem>;
            }

            /// <summary>
            /// Uploads a given video to YouTube
            /// </summary>
            /// <param name="title"></param>
            /// <param name="description"></param>
            /// <param name="path"></param>
            public async Task<IUploadProgress> UploadVideo(String title, String description, String path)
            {
                if (credential == null)
                {
                    return null;
                }

                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = this.GetType().ToString()
                });
                youtubeService.HttpClient.Timeout = TimeSpan.FromMinutes(30);//give it time to run

                var video = new Video();
                video.Snippet = new VideoSnippet();
                video.Snippet.Title = title;
                video.Snippet.Description = description;
                video.Snippet.CategoryId = "28"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                video.Status = new VideoStatus();
                if (Properties.Settings.Default.uploadYoutubeAsPrivate)
                {
                    video.Status.PrivacyStatus = "private"; // or "private" or "public"
                }
                else
                {
                    video.Status.PrivacyStatus = "public"; // or "private" or "public"
                }
                video.Status.PublicStatsViewable = false;
                var filePath = path;

                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    const int KB = 0x400;
                    var minimumChunkSize = 256 * KB;
                    var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet, status", fileStream, "video/*");
                    videosInsertRequest.NotifySubscribers = false;
                    videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                    videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

                    videosInsertRequest.ChunkSize = minimumChunkSize * 4;

                    IUploadProgress p = await videosInsertRequest.UploadAsync();
                    return p;
                }
            }

            public EventHandler<long> Upload_ProgressChanged;
            public EventHandler<String> Upload_Failed;

            /// <summary>
            /// Fire the associated event handler
            /// </summary>
            /// <param name="uploadProgress"></param>
            void videosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress uploadProgress)
            {
                switch (uploadProgress.Status)
                {
                    case UploadStatus.Uploading:
                        EventHandler<long> ea = Upload_ProgressChanged;
                        if (ea != null)
                            ea(this, uploadProgress.BytesSent);
                        break;

                    case UploadStatus.Failed:
                        EventHandler<String> eb = Upload_Failed;
                        if (eb != null)
                            eb(this, uploadProgress.Exception.ToString());
                        Console.WriteLine("An error prevented the upload from completing.\n{0}", uploadProgress.Exception);
                        break;
                }
            }

            public EventHandler<String> UploadCompleted;

            void videosInsertRequest_ResponseReceived(Video video)
            {
                EventHandler<String> ea = UploadCompleted;
                if (UploadCompleted != null)
                {
                    ea(this, video.Id);
                }
            }
        }
    }
}