﻿using System;

namespace PrimeiroProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                System.Console.WriteLine(args[i]);
            }

            Instituicao instituicao = new Instituicao();
            System.Console.Write("Informe o nome da instituição: ");
            instituicao.Nome = System.Console.ReadLine();
            System.Console.Write("Informe o endereço da instituição: ");
            instituicao.Endereco = System.Console.ReadLine();

            System.Console.WriteLine("===================================");
            System.Console.WriteLine(
                $"Obrigado por informar os dados para a {instituicao.Nome}");
            System.Console.Write("Pressione qualquer tecla para encerrar.");
            System.Console.ReadKey();
        }
    }
}
