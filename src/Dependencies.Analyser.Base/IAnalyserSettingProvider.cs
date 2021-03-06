﻿namespace Dependencies.Analyser.Base
{
    public static class SettingKeys
    {
        public static string SelectedAnalyserCode => "SelectedAnalyserCode";
        public static string ScanGlobalNative => "ScanGlobalNative";
        public static string ScanGlobalManaged => "ScanGlobalManaged";
        public static string ScanDllImport => "ScanDllImport";
        public static string ScanCliReferences => "ScanCliReferences";
    }

    public interface IAnalyserSettingProvider
    {
        void SaveSetting<T>(string code, T value);

        T GetSetting<T>(string code);

        dynamic this[string code] { get; set; }
    }
}
