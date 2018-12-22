namespace CreationalPatterns
{
    public class Singleton
    {
        private static Singleton instance = null;
        private static object objLock = new object();

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
}
