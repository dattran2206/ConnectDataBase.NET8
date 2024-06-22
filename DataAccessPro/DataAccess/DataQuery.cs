namespace DataAccess
{
    public class DataQuery : Request
    {
        public static object[] Objects;

        public static RequestCollection Create(string category, string command, params object[] args)
        {
            var query = new Request();

            query["Attributes"].Add(new NameValuePair("Category", category));
            query["Attributes"].Add(new NameValuePair("Command", command));

            foreach (var item in args)
            {
                query["Parameters"].Add(item);
            }
            Objects = args;
            return new RequestCollection(query);
        }

        public static RequestCollection Cached(string category, string command, params object[] args)
        {
            var query = new Request();

            query["Attributes"].Add(new NameValuePair("Category", category));
            query["Attributes"].Add(new NameValuePair("Command", command));

            foreach (var item in args)
            {
                query["Parameters"].Add(item);
            }

            return new RequestCollection(query);
        }
    }
}