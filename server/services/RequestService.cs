public interface IRequestService
{
    int count();
}

public class RequestService : IRequestService
{
    private static int counter = 0;

    public int count()
    {
        counter = counter + 1;
        return counter;
    }
}
