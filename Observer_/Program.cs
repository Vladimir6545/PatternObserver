using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_
{
    // Observer
    public class NewsSubscriber
    {
        public void Update(string story)
        {
            Console.WriteLine("--------------------- Breaking News ---------------------");
            Console.Write(story);
            Console.WriteLine();
        }
    }
    // Subject
    public class NewsPublisher
    {
        private readonly List<string> archive = new List<string>();

        public delegate void NotifyObserversHandler(string story);

        public event NotifyObserversHandler ArchiveChanged;

        public void PublishBreakingNews(string story)
        {
            archive.Add(story);
            if (ArchiveChanged != null)// оповещение наблюдателей
            {
                ArchiveChanged(archive[archive.Count - 1]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NewsSubscriber me = new NewsSubscriber();
            NewsPublisher publisher = new NewsPublisher();

            // подписка на событие (регистрация Observer)
            publisher.ArchiveChanged += me.Update;
            publisher.PublishBreakingNews("Hello world");

            Console.Read();
        }
    }
}
