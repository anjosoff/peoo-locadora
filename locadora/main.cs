using System;
using System.Globalization;
using System.Threading;

public class Program{
  public static void Main(){
    int op=0;
    do{
      Console.Clear();
      Console.WriteLine("Bem vindo ao sistema da LOCADORA DE VEÍCULOS LG");
      Console.WriteLine();
      op=Menu();
      switch(op){
        case 1:MainVeiculos();break;
        case 2:MainClientes();break;
        case 3:MainLocacao();break;
      }
    }while(op!=0);
    
  }

  public static int Menu(){
    Console.WriteLine("<----Escolha uma opção---->");
    Console.WriteLine("1 - Veículos");
    Console.WriteLine("2 - Clientes");
    Console.WriteLine("3 - Alocação");
    Console.WriteLine("0 - Finalizar sistema");
    Console.WriteLine("----------------------------------------");
    Console.Write("Opção: ");
    int op= int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static void MainVeiculos(){
    int opveiculo=0;
    do{
      //Console.Clear();
      Console.WriteLine("Sistema de Veículos");
      Console.WriteLine();
      opveiculo=SubMenuVeiculo();
      switch(opveiculo){
        case 1:VeiculoInserir();break;
        case 2:VeiculoAtualizar();break;
        case 3:VeiculoListar();break;
        case 4:VeiculoExcluir();break;
      }
    }while(opveiculo!=0);
  }

  public static int SubMenuVeiculo(){
    Console.WriteLine("<----Escolha uma opção---->");
    Console.WriteLine("1 - Inserir Veículos");
    Console.WriteLine("2 - Atualizar Veículos");
    Console.WriteLine("3 - Listar Veículos");
    Console.WriteLine("3 - Excluir Veículos");

    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("----------------------------------------");
    Console.Write("Opção: ");
    int opveiculo = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opveiculo;
  }

  public static void VeiculoInserir(){
    Console.WriteLine(">>> Inserir um novo veiculo <<<");
    Console.Write("Digite o ID para identifação do carro:");
    int id=int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o Modelo do veiculo:");
    string modelo=Console.ReadLine();
    Console.WriteLine("Informe o Placa do veiculo:");
    string placa=Console.ReadLine();
    Veiculo obj= new Veiculo(id,modelo,placa);
    Sistema.VeiculoInserir(obj);
    Console.WriteLine("Veiculo Registrado!");
    Console.WriteLine("----------------------------------------");
  }
  
  public static void VeiculoAtualizar(){
    Console.Write("Digite o ID do veiculo que será atualizado:");
    int id=int.Parse(Console.ReadLine());
    Console.Write("Insira o novo modelo:");
    string modelo=Console.ReadLine();
    Console.Write("Insira o a nova placa:");
    string placa=Console.ReadLine();
    Veiculo obj= new Veiculo(id,modelo,placa);
    Sistema.VeiculoAtualizar(obj);
     Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  
  public static void VeiculoListar(){
    Console.WriteLine(">>> Lista de veiculos cadastrados <<<");
    foreach(Veiculo obj in Sistema.VeiculoListar())
       Console.WriteLine(obj);
    Console.WriteLine("----------------------------------------");    
  }
  
  public static void VeiculoExcluir(){
    Console.Write("Insira o ID do veiculo que será excluído:");
    int id=int.Parse(Console.ReadLine());
    string modelo="";
    string placa="";
    Veiculo obj = new Veiculo(id,modelo,placa);
    Sistema.VeiculoExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");    
  }

  public static void MainClientes(){
    int opcliente=0;
    do{
      Console.Clear();
      Console.WriteLine("Sistema de Clientes");
      Console.WriteLine();
      opcliente=SubMenuCliente();
      switch(opcliente){
        case 1:ClienteInserir();break;
        case 2:ClienteAtualizar();break;
        case 3:ClienteListar();break;
        case 4:ClienteExcluir();break;
      }
    }while(opcliente!=0);
  }

  public static int SubMenuCliente(){
    Console.WriteLine("<----Escolha uma opção---->");
    Console.WriteLine("1 - Inserir novo cliente");
    Console.WriteLine("2 - Atualizar dados do cliente");
    Console.WriteLine("3 - Listar clientes");
    Console.WriteLine("4 - Excluir cliente");
    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("----------------------------------------");
    Console.Write("Opção: ");
    int opcliente = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcliente;
  }
  
  public static void ClienteInserir(){
  Console.WriteLine("<---- Novo Cadastro de Cliente ---->");
    Console.Write("Digite o ID para o Cliente:");
    int idcliente=int.Parse(Console.ReadLine());           
    Console.Write("Digite o nome do Cliente:");
    string nome=Console.ReadLine();
    Console.Write("Informe o CPF (somente números):");
    int cpf=int.Parse(Console.ReadLine());
    Console.Write("Informe o email:");
    string email=Console.ReadLine();
    Cliente obj= new Cliente{IdCliente=idcliente,Nome=nome,Cpf=cpf,Email=email};
    Sistema.ClienteInserir(obj);
    Console.WriteLine("Cliente cadastrado e locação realizada com sucesso!");
    Console.WriteLine("----------------------------------------");    
  }

  public static void ClienteAtualizar(){
    Console.Write("Informe o id do cliente que será atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Nome:");
    string nome= Console.ReadLine();
    Console.Write("Email:");
    string email=Console.ReadLine();
    Console.Write("CPF:");
    int cpf=int.Parse(Console.ReadLine());
    Cliente obj =  new Cliente{IdCliente=id,Nome=nome,Cpf=cpf,Email=email};
    Sistema.ClienteAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");    
  }
  
  public static void ClienteListar(){
    Console.WriteLine("<----Lista de Clientes ativos---->");
    foreach(Cliente obj in Sistema.ClienteListar())
       Console.WriteLine(obj);
    Console.WriteLine("----------------------------------------");      
  }  
  
  public static void ClienteExcluir(){
    Console.WriteLine("----- Excluir um cadastro -----");
    ClienteListar();
    Console.Write("Informe o id do Cliente que será excluído: ");
    int id = int.Parse(Console.ReadLine());
    Cliente obj =  new Cliente{IdCliente=id};
    Sistema.ClienteExcluir(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");    
  }

public static void MainLocacao(){
    int oplocacao=0;
    do{
      Console.Clear();
      Console.WriteLine("Sistema de Locação");
      Console.WriteLine();
      oplocacao=SubMenuLocacao();
      switch(oplocacao){
        case 1:LocadoraInserir();break; 
        case 2:LocadoraAtualizar();break; 
        case 3:LocadoraListar();break; 
        case 4:LocadoraExcluir();break; 
      }
    }while(oplocacao!=0);
  }

  public static int SubMenuLocacao(){
    Console.WriteLine("<----Escolha uma opção---->");
    Console.WriteLine("1 - Realizar locação");
    Console.WriteLine("2 - Atualizar locação");
    Console.WriteLine("3 - Listar locação");
    Console.WriteLine("4 - Excluir locação");
    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("----------------------------------------");
    Console.Write("Opção: ");
    int oplocacao = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return oplocacao;
  }

  public static void LocadoraInserir(){
  Console.WriteLine("<---- Novo Cadastro de locação ---->");
    Console.Write("Escolha um ID para esta locação:");
    int idloc=int.Parse(Console.ReadLine());
    Console.WriteLine("Para seleção de carros visualize os automovéis disponiveis:");
    VeiculoListar();
    Console.Write("ID do carro:");
    int idveiculo=int.Parse(Console.ReadLine());
    ClienteListar();
    int idcliente=int.Parse(Console.ReadLine());
    Locadora obj =  new Locadora{IdLocacao=idloc,IdCliente=idcliente,IdCarro=idveiculo};
    Sistema.LocadoraInserir(obj);
    Console.WriteLine("Locação realizada com sucesso!");
    Console.WriteLine("----------------------------------------");
  }
  
  public static void LocadoraAtualizar(){
    Console.WriteLine("<---- Atualizar uma locação ---->");
    LocadoraListar();
    Console.WriteLine();
    Console.Write("Informe o id da locação");
    int id = int.Parse(Console.ReadLine());
    VeiculoListar();
    Console.Write("Insira o ID de um veiculo acima:");
    int idveiculo=int.Parse(Console.ReadLine());
    ClienteListar();
    Console.Write("Insira o ID de um cliente acima: ");
    int idcliente = int.Parse(Console.ReadLine());
    Locadora obj =  new Locadora{IdLocacao=id,IdCliente=idcliente,IdCarro=idveiculo};
    Sistema.LocadoraAtualizar(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void LocadoraListar(){
    Console.WriteLine("<----Lista de Clientes ativos---->");
    foreach(Locadora obj in Sistema.LocadoraListar())
       Console.WriteLine(obj);
    Console.WriteLine("----------------------------------------");    
  }
  
  public static void LocadoraExcluir(){
    // pendente
  }
}