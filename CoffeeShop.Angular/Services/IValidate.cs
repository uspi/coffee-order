namespace CoffeeShop.Angular.Services
{
    /// <summary>
    /// Allows you to create validation methods to validate an 
    /// object with a public parameterless constructor.
    /// </summary>
    /// <typeparam name="T">Instance of class with a 
    /// public parameterless constructor</typeparam>
    public interface IValidate<T> where T : new()
    {
        bool Validate(T element);
    } 
}
