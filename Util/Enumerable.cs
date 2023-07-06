namespace Util
{
    public static class Enumerable
    {

        /// <summary>
        /// Checa se a lista de elementos informada possui conteúdo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool HasElements<T>(this IList<T> list) {
            return list != null && list.Any();
        }

    }
}
