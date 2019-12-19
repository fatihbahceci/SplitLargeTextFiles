using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileSplitter.Models
{

    public class SplitByFilterConfig : INotifyPropertyChanged
    {
        private string sourceFile;
        private string outputDirectory;
        private string splitterFilter;
        private bool isExtendedSplitterFilter;
        private int maxFileSizeBytes;

        public SplitByFilterConfig()
        {
            SplitterFilter = @")\r\n;";
            MaxFileSizeBytes = 5 * 1024 * 1024;
        }


        public string SourceFile { get => sourceFile; set { sourceFile = value; NotifyPropertyChanged(); } }
        public string OutputDirectory { get => outputDirectory; set { outputDirectory = value; NotifyPropertyChanged(); } }
        public string SplitterFilter { get => splitterFilter; set { splitterFilter = value; NotifyPropertyChanged(); } }

        public bool IsExtendedSplitterFilter { get => isExtendedSplitterFilter; set { isExtendedSplitterFilter = value; NotifyPropertyChanged(); } }

        public int MaxFileSizeBytes { get => maxFileSizeBytes; set { maxFileSizeBytes = value; NotifyPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName]string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
    public class AppConfig
    {
        public AppConfig()
        {
            SplitByFilter = new SplitByFilterConfig();
        }
        public SplitByFilterConfig SplitByFilter { get; set; }


        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static AppConfig FromJson(string value)
        {
            return JsonConvert.DeserializeObject<AppConfig>(value);
        }
    }
}
