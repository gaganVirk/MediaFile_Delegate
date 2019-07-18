using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFile_Delegates
{
    class MediaStorage
    {
        public delegate int PlayMedia();

        public void ReportResult(PlayMedia playerDelegate)
        {
            if (playerDelegate() == 0)
            {
                Console.WriteLine("Media played successfully");
            }
            else
            {
                Console.WriteLine("Media did not play successfully");
            }
        }
    }

    public class AudioPlayer
    {
        private int audioPlayerStatus;

        public int PlayAudioFile()
        {
            Console.WriteLine("Simulating playing an audio file here.");
            audioPlayerStatus = 0;
            return audioPlayerStatus;
        }
    }

    public class VideoPlayer
    {
        private int videoPlayerStatus;

        public int PlayVideoFile()
        {
            Console.WriteLine("Simulating a failed video file here.");
            videoPlayerStatus = -1;
            return videoPlayerStatus;
        }
    }

    public class Tester
    {
        public void Run()
        {
            MediaStorage myMediaStorage = new MediaStorage();

            AudioPlayer myAudioPlayer = new AudioPlayer();
            VideoPlayer myVideoPlayer = new VideoPlayer();

            MediaStorage.PlayMedia audioPlayerDelegate = new MediaStorage.PlayMedia(myAudioPlayer.PlayAudioFile);
            MediaStorage.PlayMedia videoPlayerDelegate = new MediaStorage.PlayMedia(myVideoPlayer.PlayVideoFile);

            myMediaStorage.ReportResult(audioPlayerDelegate);
            myMediaStorage.ReportResult(videoPlayerDelegate);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tester t = new Tester();
            t.Run();
        }
    }
}
