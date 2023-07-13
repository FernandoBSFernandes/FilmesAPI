namespace Util
{
    public static class PropriedadeUtil
    {

        /// <summary>
        /// Insere na classe com valores antigos os valores que estão na classe atualizada.
        /// </summary>
        /// <typeparam name="T">Classe com valores antigos.</typeparam>
        /// <typeparam name="K">Classe com valores atualizados que serão inseridos na T.</typeparam>
        /// <param name="classeComValoresAntigos">Qualquer</param>
        /// <param name="classeComValoresNovos"></param>
        public static void SetNewValues<T, K>(this T classeComValoresAntigos, K classeComValoresNovos)
            where T : class
            where K : class
        {
            var propriedadesDaClasseT = typeof(T).GetProperties();
            var propriedadesDaClasseK = typeof(K).GetProperties();

            for(int i = 0; i < propriedadesDaClasseT.Length; i++)
            {

                var nomePropriedadeClasseT = propriedadesDaClasseT[i].Name;
                var valorPropriedadeClasseT = propriedadesDaClasseT[i].GetValue(classeComValoresAntigos);
                var tipoPropriedadeClasseT = propriedadesDaClasseT[i].PropertyType;

                for(int index = 0; index < propriedadesDaClasseK.Length; index++)
                {
                    var nomePropriedadeClasseK = propriedadesDaClasseK[index].Name;
                    var valorPropriedadeClasseK = propriedadesDaClasseK[index].GetValue(classeComValoresNovos);
                    var tipoPropriedadeClasseK = propriedadesDaClasseK[index].PropertyType;

                    bool valoresNaoNulosEDiferentes =
                        valorPropriedadeClasseK != null &&
                        valorPropriedadeClasseT != null &&
                        valorPropriedadeClasseT != valorPropriedadeClasseK;

                    if (nomePropriedadeClasseT == nomePropriedadeClasseK && valoresNaoNulosEDiferentes)
                    {
                        propriedadesDaClasseT[i].SetValue(classeComValoresAntigos, valorPropriedadeClasseK);
                    }

                }

            }

        }

    }
}
