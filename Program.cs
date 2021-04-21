using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            ALUNO[] alunos = new ALUNO[30];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    Console.WriteLine("Informe o nome do aluno:");
                    ALUNO aLUNO = new ALUNO();
                    aLUNO.Nome = Console.ReadLine();

                    Console.WriteLine("informe a nota do aluno:");

                    if (decimal.TryParse(Console.ReadLine(), out decimal nota)){
                        aLUNO.Nota = nota;
                    }
                    else{
                        throw new ArgumentOutOfRangeException("Valor da nota deve ser decimal");
                    }

                    alunos[indiceAluno] = aLUNO;
                    indiceAluno++;
                        break;
                    case "2":
                    foreach(var a in alunos){
                        if (!string.IsNullOrEmpty(a.Nome)){
                        Console.WriteLine($"Aluno:{a.Nome} - Nota: {a.Nota}");
                        }
                    }
                        break;
                    case "3":
                    
                   decimal notaTotal = 0;
                    var nrAlunos= 0;

                    for (int i=0; i < alunos.Length; i++){
                        if (!string.IsNullOrEmpty(alunos[i].Nome)){
                            notaTotal = notaTotal + alunos[i].Nota;
                            nrAlunos++;
                        }
                    }

                    var mediaGeral = notaTotal / nrAlunos;
                    ConceitoEnum ConceitoGeral;

                    if ( mediaGeral < 2){
                        ConceitoGeral = ConceitoEnum.E;
                    }
                    else if (mediaGeral < 4){
                        ConceitoGeral = ConceitoEnum.D;
                    }
                     else if (mediaGeral < 6){
                        ConceitoGeral = ConceitoEnum.C;
                    }
                     else if (mediaGeral < 8){
                        ConceitoGeral = ConceitoEnum.B;
                    }
                     else{
                        ConceitoGeral = ConceitoEnum.A;
                    }
                    Console.WriteLine($"Média geral: {mediaGeral} - Conceito: {ConceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir alunos");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular media geral");
            Console.WriteLine(" x - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
