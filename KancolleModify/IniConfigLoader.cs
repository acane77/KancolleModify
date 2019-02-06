using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KancolleModify
{
    class IniConfigLoader
    {
        public static string DEFAULT_PART = "_default";
        
        string part = DEFAULT_PART;
        Dictionary<string, string> configs = new Dictionary<string, string>();

        public IniConfigLoader()
        {

        }

        public IniConfigLoader(string path)
        {
            string[] lines = null;
            try
            {
                lines = File.ReadAllLines(path);
            }
            catch
            {
                File.WriteAllText(path, "");
                return;
            }
            Regex regex = new Regex(@"^([\d|\w_\-]+)\=(.*)$");
            Regex regexPart = new Regex(@"^\s*\[\s*([\w\d_\-]+)\s*\]");
            foreach (string line in lines)
            {
                if (line.Trim() == "")
                    continue;
                Match match = regexPart.Match(line);
                if (match.Success)
                {
                    part = match.Groups[1].ToString();
                    continue;
                }
                else
                {
                    Match matches = regex.Match(line);
                    if (!matches.Success) continue;
                    string key = matches.Groups[1].ToString();
                    string value = matches.Groups[2].ToString();
                    configs[part + "." + key] = value;
                }
            }
            return;
        }

        public string GetValue(string part, string key)
        {
            return configs[part + "." + key];
        }

        public string GetValue(string name)
        {
            if (!configs.ContainsKey(name))
                return null;
            return configs[name];
        }

        public void SetValue(string key, string value)
        {
            configs[key] = value;
        }

        public void SetValue(string path, string name, string value)
        {
            SetValue(path + "." + name, value);
        }

        public bool ContainsKey(string part, string name)
        {
            return configs.ContainsKey(part + "." + name);
        }

        public bool Remove(string part, string name)
        {
            return configs.Remove(part + "." + name);
        }

        public void Clear()
        {
            configs.Clear();
        }

        private string WriteGroup(string partName, Dictionary<string, string> dict)
        {
            string content = "";
            if (partName != DEFAULT_PART)
            {
                content += "[" + partName + "]\n";
            } 
            foreach (var pair in dict)
            {
                content += pair.Key + "=" + pair.Value + "\n";
            }
            content += "\n";
            return content;
        }

        public Dictionary<string, string> GetConfigByGroupName(string name)
        {
            Dictionary<string, string> conf = new Dictionary<string, string>();
            foreach (var pair in configs)
            {
                string[] S = pair.Key.Split(new Char[] { '.' });
                if (S[0] != name)
                    continue;
                conf[S[1]] = pair.Value;
            }
            return conf;
        }

        public override string ToString()
        {
            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();

            foreach (var pair in configs)
            {
                string[] S = pair.Key.Split(new Char[] { '.' });
                if (!dict.ContainsKey(S[0]))
                {
                    dict[S[0]] = new Dictionary<string, string>();
                }
                dict[S[0]][S[1]] = pair.Value;
            }

            string content = "";

            /// write
            if (dict.ContainsKey(DEFAULT_PART))
            {
                content += WriteGroup(DEFAULT_PART, dict[DEFAULT_PART]);
                dict.Remove(DEFAULT_PART);
            }

            foreach (var pair in dict)
            {
                content += WriteGroup(pair.Key, pair.Value);
            }

            return content;
        }

        public void Write(string path)
        {
            File.WriteAllText(path, this.ToString());
        }
    }
}
