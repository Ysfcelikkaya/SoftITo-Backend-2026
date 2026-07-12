using HospitalAppApi.Models;

namespace HospitalAppApi.Services
{
    public class SymptomCheckerService
    {
        public ChatResponse AnalyzeSymptom(string message)
        {
            message = message.ToLower();
            string reply = "";
            string department = "";

            if (message.Contains("baş") || message.Contains("ağrı") || message.Contains("migren") || message.Contains("dönme"))
            {
                department = "Nöroloji";
                reply = "Şikayetinizin nörolojik bir boyutu olabilir. Size en yakın zamanda Nöroloji uzmanımızdan randevu almanızı tavsiye ederim.";
            }
            else if (message.Contains("kalp") || message.Contains("çarpıntı") || message.Contains("göğüs") || message.Contains("sol kol") || message.Contains("tansiyon"))
            {
                department = "Kardiyoloji";
                reply = "Kalp veya göğüs bölgenizdeki şikayetler ciddiye alınmalıdır. Lütfen Kardiyoloji polikliniğimizden randevu alın.";
            }
            else if (message.Contains("öksürük") || message.Contains("nefes") || message.Contains("astım") || message.Contains("balgam") || message.Contains("ciğer"))
            {
                department = "Göğüs Hastalıkları";
                reply = "Solunum yollarıyla ilgili probleminiz için Göğüs Hastalıkları polikliniğimiz size yardımcı olacaktır.";
            }
            else if (message.Contains("mide") || message.Contains("bulantı") || message.Contains("karın") || message.Contains("ishal") || message.Contains("kusma"))
            {
                department = "Dahiliye (İç Hastalıkları)";
                reply = "Sindirim sistemi veya iç organ şikayetleriniz için Dahiliye polikliniğimizden randevu alabilirsiniz.";
            }
            else if (message.Contains("göz") || message.Contains("görme") || message.Contains("bulanık") || message.Contains("miyop") || message.Contains("kızarıklık") || message.Contains("batma"))
            {
                department = "Göz Hastalıkları";
                reply = "Göz veya görme bozukluğu şikayetiniz için Göz Hastalıkları uzmanımıza başvurabilirsiniz.";
            }
            else if (message.Contains("cilt") || message.Contains("kaşıntı") || message.Contains("leke") || message.Contains("sivilce") || message.Contains("yara"))
            {
                department = "Cildiye (Dermatoloji)";
                reply = "Cilt probleminiz için Dermatoloji (Cildiye) polikliniğimize başvurmanızı tavsiye ederim.";
            }
            else if (message.Contains("çocuk") || message.Contains("bebek") || message.Contains("ateş"))
            {
                department = "Pediatri (Çocuk Sağlığı)";
                reply = "Çocuğunuzun sağlık durumu için Pediatri uzmanımızdan randevu almanız en doğrusu olacaktır.";
            }
            else
            {
                department = "Pratisyen Hekim";
                reply = "Şikayetinizi tam olarak anlayamadım. Kesin bir teşhis için Pratisyen Hekimimize muayene olabilirsiniz.";
            }

            return new ChatResponse { Reply = reply, RecommendedDepartment = department };
        }
    }
}