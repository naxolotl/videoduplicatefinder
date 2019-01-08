using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace DuplicateFinderEngine.Data
{
    public class DuplicateItem
    {
        public DuplicateItem(VideoFileEntry file)
        {
            Path = file.Path;
            Folder = file.Folder;
            Duration = file.mediaInfo.Duration;

            for (var i = 0; i < file.mediaInfo.Streams.Length; i++)
            {
                if (file.mediaInfo.Streams[i].CodecType.Equals("video", StringComparison.OrdinalIgnoreCase))
                {
                    Format = file.mediaInfo.Streams[i].CodecName;
                    Fps = file.mediaInfo.Streams[i].FrameRate;
                    BitRateKbs = Math.Round((decimal)file.mediaInfo.Streams[i].BitRate / 1000);
                    FrameSize = file.mediaInfo.Streams[i].Width + "x" + file.mediaInfo.Streams[i].Height;
                    FrameSizeInt = file.mediaInfo.Streams[i].Width + file.mediaInfo.Streams[i].Height;
                }
                else if (file.mediaInfo.Streams[i].CodecType.Equals("audio", StringComparison.OrdinalIgnoreCase))
                {
                    AudioFormat = file.mediaInfo.Streams[i].CodecName;
                    AudioChannel = file.mediaInfo.Streams[i].ChannelLayout;
                    AudioSampleRate = file.mediaInfo.Streams[i].SampleRate;
                }
            }
            var fi = new FileInfo(Path);
            DateCreated = fi.CreationTimeUtc;
            SizeLong = fi.Length;
            Size = Utils.BytesToString(fi.Length);
        }

        [DisplayName("Group Id")]
        public Guid GroupId { get; set; }
        [DisplayName("Thumbnail")]
        public List<Image> Thumbnail { get; set; } = new List<Image>();
        [DisplayName("Path")]
        public string Path { get; }
        public long SizeLong { get; }
        [DisplayName("Size")]
        public string Size { get; }
        
        public string Folder { get; }
        [DisplayName("Duration")]
        public TimeSpan Duration { get; }
        [DisplayName("Frame Size")]
        public string FrameSize { get; }
        public int FrameSizeInt { get; }
        [DisplayName("Format")]
        public string Format { get; }
        [DisplayName("Audio Format")]
        public string AudioFormat { get; }
        [DisplayName("Audio Channel")]
        public string AudioChannel { get; }
        [DisplayName("Audio Sample Rate")]
        public int AudioSampleRate { get; }
        [DisplayName("Bitrate Kbs")]
        public decimal BitRateKbs { get; }
        [DisplayName("Fps")]
        public float Fps { get; }
        [DisplayName("Created On")]
        public DateTime DateCreated { get; }


    }
}