using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SortImage
{
    class Data
    {
        //Dictionary<int, int> link;
        MultiValueDictionary<int, int> link;
        Dictionary<int, string> tags;
        Dictionary<int, string> filenames;
        Dictionary<string, string> tagLogic;

        public Data()
        {
            link = new MultiValueDictionary<int, int>();
            tags = new Dictionary<int,string>();
            tagLogic = new Dictionary<string, string>();
            filenames = new Dictionary<int, string>();
           // FillData();
        }

        string hurr = "";

        private string GetTagStruct(string tag)
        {
           // hurr += tag;
            if (tagLogic.ContainsKey(tag))
            {
                string hightag = tagLogic[tag];
                hurr += ">" + hightag;
               return GetTagStruct(hightag);
            }
            else
            {
                return hurr + "\n";
            }
        }


        public string OutputTags()
        {
            string durr ="";
            foreach (KeyValuePair<int, string> entry in filenames)
            {
                HashSet<int> value = link.GetValues(entry.Key, true);
                foreach (int i in value)
                {
                    if (tags.ContainsKey(i))
                    {
                        hurr = tags[i];
                        durr += ":" + GetTagStruct(tags[i]);
                    }
                }
                durr += Environment.NewLine;
            }
           return durr;
        }

        public void LoadTags()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("C://tags.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split('|');
                tagLogic.Add(words[0], words[1]);
                counter++;
            }

            file.Close();
        }


        public void TagsFromTree()
        {
            //
        }

        public void Save()
        {
            //
          //  TagsFromTree()

            TextWriter tw = new StreamWriter("C://test2.txt");
            string l = "";
            foreach (KeyValuePair<int, string> entry in filenames)
            {
                HashSet<int> value = link.GetValues(entry.Key, true);
                l = entry.Value;
                foreach (int i in value)
                {
                    if (tags.ContainsKey(i))
                    {
                        l += "|" + tags[i];
                    }
                }
                tw.WriteLine(l);
            }
            tw.Close();
        }

        public void Load()
        {
            int counter = 0;
            int pos = 0;
            int linkpos = 0;
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader("C://test.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split('|');

                filenames.Add(counter, words[0]);

                int count = 1;

                //Get tags
                while (count < words.Length)
                {
                    //Tag already in list
                    if (!tags.ContainsValue(words[count]))
                    {
                        tags.Add(pos, words[count]);
                        linkpos = pos;
                        pos++;
                    }
                    //Tag is new
                    else
                    {
                        linkpos = findMyValue(tags, words[count]); //Linear search sould be fine as tag list should be minimal
                    }
                    link.Add(counter, linkpos);
                    count++;
                }
                counter++;
            }
            file.Close();
        }

        public int findMyValue(Dictionary<int, string> myDic, string val)
        {
            foreach (int key in myDic.Keys)
            {
                if (myDic[key] == val)
                {
                    return key;
                }
            }
            return -1;
        }


        private void FillData()
        {
            filenames.Add(1, "C:/rr/ss");
            filenames.Add(2, "C:/rr/ss");

            link.Add(1, 1);
            link.Add(1, 2);
            link.Add(2, 1);
            link.Add(2, 3);

            tags.Add(1, "A");
            tags.Add(2, "B");
            tags.Add(3, "C");
        }

        public void PrintData(int il)
        {
            if (link.ContainsKey(il))
            {
                HashSet<int> value = link.GetValues(il, true);
                foreach (int i in value)
                {
                    if (tags.ContainsKey(i))
                    {
                        Console.WriteLine(tags[i]);
                    }
                }
            }
        }
    }
}
