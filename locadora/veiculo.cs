using System;
using System.Collections.Generic;

public class Veiculo: IComparable <Veiculo>{
  private int idVeiculo;
  public int IdVeiculo{
    set{idVeiculo=value;}
    get{return idVeiculo;}
  }
  private string modelo;
  public string Modelo{
    set{modelo=value;}
    get{return modelo;}
  }
  private string placa;
  public string Placa{
    set{placa=value;}
    get{return placa;}
  }
  public Veiculo(int idveiculo,string modelo, string placa){
    this.idVeiculo=idveiculo;
    this.modelo=modelo;
    this.placa=placa;
  }
  public Veiculo(){
    
  }
  public void SetModelo(string modelo){
    this.modelo=modelo;
  }
  public void SetPlaca(string placa){
    this.placa=placa;
  }
  public void SetIdVeiculo(int idveiculo){
    this.IdVeiculo=idveiculo;
  }
  public string GetPlaca(){
    return placa;
  }
  public string GetModelo(){
    return modelo;
  }
  public int GetIdVeiculo(){
    return idVeiculo;
  }
  public override string ToString(){
    return $"\nID: {IdVeiculo}\n Modelo: {modelo}\n  Placa:{placa}";
  }
  public int CompareTo(Veiculo obj){
    return modelo.CompareTo(obj.GetModelo());
  }
}