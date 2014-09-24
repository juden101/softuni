using System;
using System.Collections.Generic;

class Program
{
    struct Site
    {
        public string URL;
        public double loadTime;
        public int visits;

        public Site(string u, double l, int v)
        {
            URL = u;
            loadTime = l;
            visits = v;
        }
    }

    static void Main()
    {
        List<Site> visits = new List<Site>();
        
        while(true)
        {
            string[] currentSite = Console.ReadLine().Split();

            if (currentSite[0].Length == 0)
            {
                break;
            }
            else
            {
                string currentURL = currentSite[2];
                double currentLoadTime = Convert.ToDouble(currentSite[3].ToString());
                
                if(visits.Count == 0)
                {
                    visits.Add(new Site(currentURL, currentLoadTime, 1));
                }
                else
                {
                    bool foundSite = false;

                    for (int i = 0; i < visits.Count; i++)
                    {
                        if (visits[i].URL == currentURL)
                        {
                            foundSite = true;
                            visits[i] = new Site(currentURL, visits[i].loadTime + currentLoadTime, visits[i].visits + 1);
                        }
                    }

                    if (!foundSite)
                    {
                        visits.Add(new Site(currentURL, currentLoadTime, 1));
                    }
                }
            }
        }

        foreach (var item in visits)
        {
            Console.WriteLine("{0} -> {1}", item.URL, item.loadTime / item.visits);
        }
    }
}