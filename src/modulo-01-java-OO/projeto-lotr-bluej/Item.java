// Define classe Item
public class Item {
    private int quantidade;
    private String descricao;
    
    public Item(int quantidade, String descricao) {
        this.quantidade = quantidade;
        this.descricao = descricao;
    }
    
    public int getQuantidade() {
        return this.quantidade;
    }
    
    public String getDescricao() {
        return this.descricao;
    }
    
    public void aumentar1000Unidades() {
        this.quantidade += 1000;
    }
    
    public void aumentarProporcionalQuantidade() {
        /*int resultado = 0;
        for (int i = 1; i <= this.quantidade; i++) {
            resultado += i;
        }*/
        // Usando PA:
        int resultado = this.quantidade * (this.quantidade + 1) / 2;
        this.quantidade += (resultado * 1000);
    }
}