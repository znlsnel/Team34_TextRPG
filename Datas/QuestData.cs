using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team34_TextRPG
{
    public class QuestData
    {
        
        public string name;
        public string description;
        public bool IsCompleted;

        public QuestData(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.IsCompleted = false;
        }
    }
        public class MainQuest : QuestData
        {
            public MainQuest(string name, string description) : base(name, description)
            {
            }
        }
    }
