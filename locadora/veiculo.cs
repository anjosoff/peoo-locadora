using System;
class Veiculo{
  private int IdVeiculo;
  private string modelo;
  private string placa;
  public Veiculo(int idveiculo,string modelo, string placa){
    this.IdVeiculo=idveiculo;
    this.modelo=modelo;
    this.placa=placa;
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
    return IdVeiculo;
  }
  public override string ToString(){
    return $"ID: {IdVeiculo}\n Modelo: {modelo}\n  Placa:{placa}";
  }
}