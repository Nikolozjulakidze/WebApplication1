

namespace FilmsApi.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(
            int id, string type):base($"{type}Entity with id:{id} not found")
        {  
        }

        public NotFoundException(string email):base($"{email} not found")
        {
        }
    }
}
