using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.Translation
{
    public class GoogleTranslator
    {
        TranslationClient googlerTranslatorClient;
        public GoogleTranslator(string path)
        {
            var creds = GoogleCredential.FromFile(Path.Combine(path, "helper/Saudiceos-28cc1dde9762.json"));
            googlerTranslatorClient = TranslationClient.Create(creds);
        }
        public static GoogleTranslator  Instance(string path)
        {
            return new GoogleTranslator(path);
        }
             
        public string TranslateEnglish(string text)
        {  
            var response = googlerTranslatorClient.TranslateText(text, LanguageCodes.Arabic, LanguageCodes.English);
            return response.TranslatedText;
        }
        public string TranslateArabic(string text)
        {
            try {
                var response = googlerTranslatorClient.TranslateText(text, LanguageCodes.English, LanguageCodes.Arabic);
                return response.TranslatedText;
            }
            catch (Exception xx)
            {
                return text;
            }
        }
        public async Task<bool> IsArabic(string txt)
        {
            var detectLang = await googlerTranslatorClient.DetectLanguageAsync(txt);
            return detectLang.Language.ToLower() == "ar";
        }
    }
}
