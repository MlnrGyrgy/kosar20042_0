namespace kosar20042_0
{
    class Meccs
    {
        public string Hazai { get; private set; }
        public string Idegen { get; private set; }
        public int HPont { get; private set; }
        public int IPont { get; private set; }
        public string Hely { get; private set; }
        public string Idopont { get; private set; }

        public Meccs(string Hazai, string Idegen, int HPont, int IPont, string Hely, string Idopont)
        {
            this.Hazai = Hazai;
            this.Idegen = Idegen;
            this.HPont = HPont;
            this.IPont = IPont;
            this.Hely = Hely;
            this.Idopont = Idopont;
        }
        public string Eredmeny()
        {
            return Hazai + "-" + Idegen + " " + HPont + ":" + IPont;
        }
       
    }
}