using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Config
    {
        public Config()
        {
            _config = new Dictionary<string, Dictionary<string, string>>();
        }

        public string Get(string section, string option)
        {
            if (this.HasOption(section, option))
                return _config[section][option];

            return "";
        }

        public int Getint(string section, string option)
        {
            int rv = 0;
            if (this.HasOption(section, option))
                if (int.TryParse(_config[section][option], out rv))
                    return rv;

            return 0;
        }

        public float Getfloat(string section, string option)
        {
            float rv = 0;
            if (this.HasOption(section, option))
                if (float.TryParse(_config[section][option], out rv))
                    return rv;

            return 0;
        }

        public bool Getboolean(string section, string option)
        {
            if( this.HasOption( section, option ))
            {
                string value = _config[section][option];
                if (value == "1" || value == "yes" || value == "true"  || value == "on")
                    return true;

                if (value == "0" || value == "no" || value == "false" || value == "off")
                    return false;
            }

            return false;
        }

        public bool HasSection(string section)
        {
            return _config.ContainsKey(section);
        }

        public bool HasOption( string section, string option )
        {
            return _config.ContainsKey(section) && _config[section].ContainsKey(option);
        }

        public void Set( string section, string option, string value )
        {
            if( this.HasSection( section ))
            {
                _config[section][option] = value;
            }
        }

        public void AddSection(string section)
        {
            if (!this.HasSection(section))
            {
                _config[section] = new Dictionary<string, string>();
            }
        }

        public string[] Sections()
        {
            string[] sections = new string[_config.Count()];
            for (int i = 0; i < _config.Count(); ++i)
            {
                sections[i] = _config.Keys.ElementAt(i);
            }

            return sections;
        }

        public Tuple<string, string>[] Items(string section)
        {
            Tuple<string, string>[] items;
            if (!this.HasSection(section))
                items = new Tuple<string, string>[0];
            else
            {
                items = new Tuple<string, string>[_config[section].Count()];

                int index = 0;
                foreach( KeyValuePair<string,string> item in _config[section] )
                {
                    items[index++] = Tuple.Create(item.Key, item.Value);
                }
            }

            return items;
        }

        public string [] Read( string [] filenames )
        {
            string[] read_files = new string[filenames.Count()];


            return read_files;
        }

        public void RemoveSection(string section)
        {
            if (this.HasSection(section))
            {
                _config.Remove(section);
            }
        }

        public void RemoveOption(string section, string option)
        {
            if (this.HasOption(section, option))
            {
                _config[section].Remove(option);
            }
        }

        public override string ToString()
        {
            string rv = base.ToString() + endl; 
            foreach( KeyValuePair<string,Dictionary<string,string>> item in _config )
            {
                rv += "[ " + item.Key + " ]" + endl;
                foreach( KeyValuePair<string,string> option in item.Value )
                {
                    rv += option.Key + " = " + option.Value + endl;
                }

                rv += endl;
            }

            return rv;
        }

        public static bool debug { protected set; get; }

        private Dictionary<string, Dictionary<string, string>> _config;
        private static string endl = Environment.NewLine;
    }
}
