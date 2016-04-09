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
        /*    descricao += this.itens.get(i).getDescricao() + ",";
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

    public void ordenarItens() {
        // Versão mais estável do Bubblesort - Melhor caso O(n), Pior caso O(n^2)
        // homenagem ao do-while: para forçar entrada na lógica
        boolean posicoesSendoTrocadas;
        do {
            posicoesSendoTrocadas = false;
            for (int j = 0; j < this.itens.size() - 1; j++) {
                Item itemAtual = this.itens.get(j);
                Item proximo = this.itens.get(j + 1);

                boolean precisaTrocar = 
                    itemAtual.getQuantidade() > proximo.getQuantidade();

                if (precisaTrocar) {
                    this.itens.set(j, proximo);
                    this.itens.set(j + 1, itemAtual);
                    posicoesSendoTrocadas = true;
                }
            }
        } while (posicoesSendoTrocadas);
    }
}






