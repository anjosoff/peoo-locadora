using System;
using System.Globalization;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

public class Program{
  public static void Main(){
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
    int op=0;
    do{
      try{
        Console.Clear();
        Console.WriteLine("Seja bem-vindo(a) ao sistema da Locadora de Veículos - LG");
        Console.WriteLine();
        op=Menu();
        switch(op){
          case 1:MainVeiculos();break;
          case 2:MainClientes();break;
          case 3:MainLocacao();break;
          case 4:MainDados();break;
          case 0:;break;
          default: Console.WriteLine("---------------------------------------\nOpção não encontrada!\n----------------------------------------\n");break;
        }
      }catch(Exception erro){
        Console.WriteLine("Erro:"+erro.Message);
      }
    Thread.Sleep(1000);
    }while(op!=0);
  }

  public static int Menu(){
    Console.WriteLine("<---- Menu Principal ---->\n");
    Console.WriteLine("Escolha uma opção:\n");
    Console.WriteLine("1 - Veículos");
    Console.WriteLine("2 - Clientes");
    Console.WriteLine("3 - Alocação");
    Console.WriteLine("4 - Dados do sistema");    
    Console.WriteLine("0 - Finalizar sistema");
    Console.WriteLine("\n------------------------------");
    Console.Write("\nOpção: ");
    int op= int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static void MainVeiculos(){
    int opveiculo=0;
    do{
      try{
        Console.Clear();
        Console.WriteLine("<---- Menu de Veículos ---->\n");      
      Console.WriteLine();
      opveiculo=SubMenuVeiculo();
      switch(opveiculo){
        case 1:VeiculoInserir();break;
        case 2:VeiculoAtualizar();break;
        case 3:VeiculoListar();break;
        case 4:VeiculoExcluir();break;
        case 0:;break;
        default: Console.WriteLine("---------------------------------------\nOpção não encontrada!\n----------------------------------------\n");break;
      }
      }catch(FormatException){
        Console.WriteLine("Digite apenas números");
      }
    Thread.Sleep(1000);
    }while(opveiculo!=0);
  }

  public static int SubMenuVeiculo(){
    Console.WriteLine("Escolha uma opção:\n");
    Console.WriteLine("1 - Inserir Veículos");
    Console.WriteLine("2 - Atualizar Veículos");
    Console.WriteLine("3 - Listar Veículos");
    Console.WriteLine("4 - Excluir Veículos");

    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("\n------------------------------");
    Console.Write("\nOpção: ");
    int opveiculo = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opveiculo;
  }

  public static void VeiculoInserir(){
    Console.Clear();
    Console.WriteLine("<---- Inserir Veículo ---->\n"); 
    Console.Write("Digite o ID para a identificação do veículo: ");
    int id=int.Parse(Console.ReadLine());
    Console.Write("\nInforme o modelo do veiculo: ");
    string modelo=Console.ReadLine();
    Console.Write("\nInforme a placa do veiculo: ");
    string placa=Console.ReadLine();
    Veiculo obj= new Veiculo(id,modelo,placa);
    Sistema.VeiculoInserir(obj);
    Console.WriteLine("\nVeiculo registrado!");
    Console.WriteLine("\n------------------------------");
    Thread.Sleep(1000);
  }
  
  public static void VeiculoAtualizar(){
    Console.Clear();
    VeiculoListar();
    Console.WriteLine("<---- Atualizar dados de um Veículo ---->\n"); 
    Console.Write("Digite o ID do veiculo que será atualizado: ");
    int id=int.Parse(Console.ReadLine());
    Console.Write("\nInsira o novo modelo: ");
    string modelo=Console.ReadLine();
    Console.Write("\nInsira o a nova placa: ");
    string placa=Console.ReadLine();
    Veiculo obj= new Veiculo(id,modelo,placa);
    Sistema.VeiculoAtualizar(obj);
     Console.WriteLine("\n----- Operação realizada com sucesso -----");
    Thread.Sleep(1000);
  }
  
  public static void VeiculoListar(){
    Console.Clear();
    Console.WriteLine("<---- Lista de veiculos cadastrados ---->"); 
    foreach(Veiculo obj in Sistema.VeiculoListar())
       Console.WriteLine(obj.ToString());
    Console.WriteLine("\n------------------------------"); 
    Thread.Sleep(5000);
  }
  
  public static void VeiculoExcluir(){
    Console.Clear();
    VeiculoListar();
    Console.WriteLine("<---- Excluindo um veiculo ---->\n"); 
    Console.Write("Insira o ID do veiculo que será excluído: ");
    int id=int.Parse(Console.ReadLine());
    string modelo="";
    string placa="";
    Veiculo obj = new Veiculo(id,modelo,placa);
    Sistema.VeiculoExcluir(obj);
    Console.WriteLine("\n----- Operação realizada com sucesso -----");
    Thread.Sleep(1000);
  }
  
  public static void MainClientes(){
    int opcliente=0;
    do{
      try{
        Console.Clear();
        Console.WriteLine("<----  Menu de Clientes ----> \n");
        opcliente=SubMenuCliente();
        switch(opcliente){
          case 1:ClienteInserir();break;
          case 2:ClienteAtualizar();break;
          case 3:ClienteListar();break;
          case 4:ClienteExcluir();break;
          case 0:;break;
          default: Console.WriteLine("---------------------------------------\nOpção não encontrada!\n----------------------------------------\n");break;
        }
      }catch(FormatException){
        Console.WriteLine("Digite apenas números!");
      }
    Thread.Sleep(1000);
    }while(opcliente!=0);
  }

  public static int SubMenuCliente(){
    Console.WriteLine("Escolha uma opção: \n");
    Console.WriteLine("1 - Inserir novo cliente");
    Console.WriteLine("2 - Atualizar dados do cliente");
    Console.WriteLine("3 - Listar clientes");
    Console.WriteLine("4 - Excluir cliente");
    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("\n------------------------------"); 
    Console.Write("Opção: ");
    int opcliente = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcliente;
  }
  
  public static void ClienteInserir(){
    Console.Clear();
    Console.WriteLine("<---- Novo Cadastro de Cliente ---->\n");   
    Console.Write("Digite o ID para o Cliente: ");
    int idcliente=int.Parse(Console.ReadLine());         
    Console.Write("\nDigite o nome do Cliente: ");
    string nome=Console.ReadLine();
    Console.Write("\nInforme o CPF (somente números): ");
    long cpf=long.Parse(Console.ReadLine());
    Console.Write("\nInforme o email: ");
    string email=Console.ReadLine();
    Cliente obj= new Cliente{IdCliente=idcliente,Nome=nome,Cpf=cpf,Email=email};
    Sistema.ClienteInserir(obj);
    Console.WriteLine("\n----- Operação realizada com sucesso -----"); 
    Thread.Sleep(1000);
  }

  public static void ClienteAtualizar(){
    Console.Clear();
    ClienteListar();
    Console.WriteLine("<---- Atualizar um cliente ---->\n"); 
    Console.Write("Informe o id do cliente que será atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("\nNome: ");
    string nome= Console.ReadLine();
    Console.Write("\nEmail: ");
    string email=Console.ReadLine();
    Console.Write("\nCPF: ");
    int cpf=int.Parse(Console.ReadLine());
    Cliente obj =  new Cliente{IdCliente=id,Nome=nome,Cpf=cpf,Email=email};
    Sistema.ClienteAtualizar(obj);
    Console.WriteLine("\n----- Operação realizada com sucesso -----");    
    Thread.Sleep(1000);
  }
  
  public static void ClienteListar(){
    Console.Clear();
    Console.WriteLine("<---- Lista de clientes ativos ---->\n"); 
    foreach(Cliente obj in Sistema.ClienteListar())
       Console.WriteLine(obj.ToString());
    Console.WriteLine("------------------------------"); 
    Thread.Sleep(4000);
  }  
  
  public static void ClienteExcluir(){
    ClienteListar();
    Console.WriteLine("<---- Excluir um cliente ----> \n"); 
    ClienteListar();
    Console.Write("Informe o id do cliente que será excluído: ");
    int id = int.Parse(Console.ReadLine());
    Cliente obj =  new Cliente{IdCliente=id};
    Sistema.ClienteExcluir(obj);
    Console.WriteLine("\n----- Operação realizada com sucesso -----");
    Thread.Sleep(1000);
  }

public static void MainLocacao(){
    int oplocacao=0;
    do{
      try{
        Console.Clear();
        Console.WriteLine("<----  Menu de Locação ----> \n");
        oplocacao=SubMenuLocacao();
        switch(oplocacao){
          case 1:LocacaoInserir();break; 
          case 2:LocacaoAtualizar();break; 
          case 3:LocacaoListar();break; 
          case 4:LocacaoExcluir();break;

          case 0:;break;
          default: Console.WriteLine("---------------------------------------\nOpção não encontrada!\n----------------------------------------\n");break;
        }
      }catch(FormatException){
        Console.WriteLine("Digite apenas números");
      }
    Thread.Sleep(1000);
    }while(oplocacao!=0);
  }

  public static int SubMenuLocacao(){
    Console.WriteLine("Escolha uma opção:\n");
    Console.WriteLine("1 - Realizar locação");
    Console.WriteLine("2 - Atualizar locação");
    Console.WriteLine("3 - Listar locação");
    Console.WriteLine("4 - Excluir locação");
    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("\n------------------------------"); 
    Console.Write("\nOpção: ");
    int oplocacao = int.Parse(Console.ReadLine());
    return oplocacao;
  }

  public static void LocacaoInserir(){
    DateTime data = new DateTime();
    Console.Clear();
    Console.WriteLine("<---- Novo Cadastro de Locação ---->"); 
    Console.Write("\nEscolha um ID para esta locação: ");
    int idloc=int.Parse(Console.ReadLine());
    Console.WriteLine("\nPara seleção de veículos visualize os automovéis disponiveis:\n");
    VeiculoListar();
    Console.Write("\nID do veículo que deseja alocar: ");
    int idveiculo=int.Parse(Console.ReadLine());
    ClienteListar();
    Console.Write("\nID do cliente que deseja alocar: ");    
    int idcliente=int.Parse(Console.ReadLine());
    Console.Write("\nDigite a data de retirada(enter para a data de hoje): ");
    string d=Console.ReadLine(); 
    if(d==""){
      data = DateTime.Now;
    }else{
      data = DateTime.Parse(d);
    }
    Console.Write("\nDigite a data de devolução(dd/mm/aaaa): ");
    DateTime data2= DateTime.Parse(Console.ReadLine());
    Locacao obj = new Locacao{IdLocacao=idloc,IdCliente=idcliente,IdVeiculo=idveiculo, Dretira=data, Ddevolve=data2};
    Sistema.LocacaoInserir(obj);
    Console.WriteLine("\n----- Operação realizada com sucesso -----");
    Thread.Sleep(1000);
  }
  
  public static void LocacaoAtualizar(){
    DateTime data = new DateTime();
    Console.Clear();
    LocacaoListar();
    Console.WriteLine("<---- Atualizar uma Locação ---->"); 
     LocacaoListar();
    Console.Write("\nInforme o ID da locação: ");
    int id = int.Parse(Console.ReadLine());
    VeiculoListar();
    Console.Write("\nInsira o ID de um dos veiculos acima: ");
    int idveiculo=int.Parse(Console.ReadLine());
    ClienteListar();
    Console.Write("\nInsira o ID de um dos clientes acima: ");
    int idcliente = int.Parse(Console.ReadLine());
    Console.Write("\nDigite a data de retirada(enter para a data de hoje): ");
    string d=Console.ReadLine(); 
    if(d==""){
      data = DateTime.Now;
    }else{
      data = DateTime.Parse(d);
    }
    Console.Write("\nDigite a data de devolução(dd/mm/aaaa): ");
    DateTime data2= DateTime.Parse(Console.ReadLine());
    Locacao obj =  new Locacao{IdLocacao=id,IdCliente=idcliente,IdVeiculo=idveiculo, Dretira=data, Ddevolve=data2};
    Sistema.LocacaoAtualizar(obj);
    Console.WriteLine("\n----- Operação realizada com sucesso -----");
    Thread.Sleep(1000);
  }

  public static void LocacaoListar(){ //LISTANDO POR ORDEM DE DATA RETIRADA
    Console.Clear();
    Console.WriteLine("<---- Lista de Locações ---->");     
    foreach(Locacao obj in Sistema.LocacaoListar()) { 
      Veiculo v = Sistema.VeiculoListar(obj.IdVeiculo);
      Cliente c = Sistema.ClienteListar(obj.IdCliente);
      Console.WriteLine("------------------------------");
      Console.WriteLine($"\nID:{obj.IdLocacao}\nData de retirada:{obj.Dretira}\nData de devolução:{obj.Ddevolve}\nCliente:\n{c.Nome} - {c.Cpf} - E-mail:{c.Email}\nVeículo:\n{v.GetModelo()} - {v.GetPlaca()}");
    Console.WriteLine("\n------------------------------"); 
    }
    Thread.Sleep(5000);
  }
  public static void LocacaoExcluir(){
    Console.Clear();
    LocacaoListar();
    Console.WriteLine("<---- Excluir uma Locação ---->\n");
    LocacaoListar();
    Console.Write("\nInforme o id da locação que será excluída: ");
    int id = int.Parse(Console.ReadLine());
    Locacao obj =  new Locacao{IdLocacao=id};
    Sistema.LocacaoExcluir(obj);
    Console.WriteLine("\n----- Operação realizada com sucesso -----"); 
    Thread.Sleep(1000);
  }

 public static void MainDados(){
  int opdados=0;
    do{
      try{
        Console.Clear();
        Console.WriteLine("<----  Menu de Dados ----> \n");
        opdados=SubMenuDados();
        switch(opdados){
          case 1:Sistema.ToXML();Console.WriteLine("\nOs dados da locação foram salvos");break;
          case 2:Sistema.FromXML();break;
          case 0:;break;
          default: Console.WriteLine("---------------------------------------\nOpção não encontrada!\n----------------------------------------\n");break;
        }
      }catch(FormatException){
        Console.WriteLine("Digite apenas números!");
      }
    Thread.Sleep(1000);
    }while(opdados!=0);
 }

  public static int SubMenuDados(){
    Console.WriteLine("Escolha uma opção: \n");
    Console.WriteLine("1 - Salvar dados");
    Console.WriteLine("2 - Recuperar últimos dados salvos");
    Console.WriteLine("0 - Voltar ao Menu Principal");
    Console.WriteLine("\n------------------------------"); 
    Console.Write("Opção: ");
    int opdados = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opdados;
  }
//
}