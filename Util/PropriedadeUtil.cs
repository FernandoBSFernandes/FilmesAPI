namespace Util
{
    public static class PropriedadeUtil
    {

        /// <summary>
        /// Insere na classe com valores antigos os valores que estão na classe atualizada.
        /// </summary>
        /// <typeparam name="T">Classe com valores antigos.</typeparam>
        /// <typeparam name="K">Classe com valores atualizados que serão inseridos na T.</typeparam>
        /// <param name="classeComValoresAntigos">A classe que possui valores que devem ser atualizados.</param>
        /// <param name="classeComValoresNovos">A classe que possui os valores atualizados a serem passados pra classe do primeiro parâmetro.</param>
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

                    bool propriedadesPossuemMesmoNome = nomePropriedadeClasseT == nomePropriedadeClasseK;

                    bool propriedadesSaoDoMesmoTipo = tipoPropriedadeClasseT == tipoPropriedadeClasseK;
                    
                    bool valoresNaoNulosEDiferentes =
                        valorPropriedadeClasseK != null &&
                        valorPropriedadeClasseT != null &&
                        valorPropriedadeClasseT != valorPropriedadeClasseK;

                    if (propriedadesPossuemMesmoNome && propriedadesSaoDoMesmoTipo && valoresNaoNulosEDiferentes)
                        propriedadesDaClasseT[i].SetValue(classeComValoresAntigos, valorPropriedadeClasseK);

                }

            }

        }

    }
}
