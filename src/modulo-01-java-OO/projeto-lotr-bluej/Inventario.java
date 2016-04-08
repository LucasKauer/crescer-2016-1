import java.util.ArrayList;

public class Inventario {
    private ArrayList<Item> itens = new ArrayList<>();
    
    public void adicionarItem(Item item) {
        this.itens.add(item);
    }
    
    public void removerItem(Item item) {
        this.itens.remove(item);
    }
    
    public ArrayList<Item> getItens() {
        return this.itens;
    }
    
    public String getDescricoesItens() {
        String descricao = "";
        
        for (Item item : this.itens) {
            descricao += item.getDescricao() + ",";
        }
        
        // C#
        // foreach (var item in this.itens)
        
        /*for (int i = 0; i < this.itens.size(); i++) {
            descricao += this.itens.get(i).getDescricao() + ",";
        }*/
        /*
        int i = 0;
        while (i < this.itens.size()) {
            descricao += this.itens.get(i).getDescricao() + ",";
            i++;
        }*/
        /*
        int i = 0;
        do {
            descricao += this.itens.get(i).getDescricao() + ",";
            i++;
        } while (i < this.itens.size());
        */
        
        return !this.itens.isEmpty() ? descricao.substring(0, descricao.length() - 1) : descricao;
    }
    
    public void aumentar1000UnidadesPorItem() {
        for (Item item : this.itens) {
            item.aumentar1000Unidades();
        }
    }
    
    public Item getItemComMaiorQuantidade() {
        int indice = 0, maiorQtdAteEntao = 0;
        for (int i = 0; i < this.itens.size(); i++) {
            int qtdAtual = this.itens.get(i).getQuantidade();
            if (qtdAtual > maiorQtdAteEntao) {
                indice = i;
                maiorQtdAteEntao = qtdAtual;
            }
        }
        
        return !this.itens.isEmpty() ? this.itens.get(indice) : null;
    }
}











