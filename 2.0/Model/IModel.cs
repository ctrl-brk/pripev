namespace Pripev.Model
{
   public interface IModel
   {
      void Clear();
      void Retrieve();
      void Save( int modifiedBy );
      void Delete();
   }
}
