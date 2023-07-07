namespace Util
{
    public static class Enumerable
    {

        /// <summary>
        /// Checa se a lista de elementos informada possui conteúdo. A lista não deve ser de struct.
        /// </summary>
        /// <returns>True, caso a lista informada possui elementos e não está nula; False, caso contrário.</returns>
        public static bool HasElements<T>(this IList<T> list) where T : class
        {
            return list != null && list.Any();
        }

    }
}
