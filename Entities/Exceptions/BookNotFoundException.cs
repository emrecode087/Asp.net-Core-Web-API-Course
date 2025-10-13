namespace Entities.Exceptions
{
    // sealed => kalıtılması mümkün olmayack BookNotFound
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"The book with : {id} could not found! ")
        {

        }
    }
}

