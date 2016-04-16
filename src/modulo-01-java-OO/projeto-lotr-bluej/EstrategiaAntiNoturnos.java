import java.util.*;

public class EstrategiaAntiNoturnos implements EstrategiaDeAtaque {
    private ArrayList<Elfo> ordemDoUltimoAtaque = new ArrayList<>();

    public ArrayList<Elfo> getOrdemDoUltimoAtaque() {
        return this.ordemDoUltimoAtaque;
    }

    public void atacar(ArrayList<Elfo> pelotao, ArrayList<Dwarf> dwarves) {
        this.ordemDoUltimoAtaque.clear();

        // 1 - Variáveis de controle para quantidade de ataques.
        int intencoesAtaque = pelotao.size() * dwarves.size();
        int limiteAtaquesElfosNoturnos = (int)(intencoesAtaque * 0.3);
        int qtdAtaquesFeitosPorNoturnos = 0;

        // 2 - Percorrendo lista de vivos para desferir os ataques seguindo as regras
        for (Elfo elfoQueVaiAtacar : pelotao) {
            if (elfoQueVaiAtacar.getStatus() == Status.VIVO) {
                for (Dwarf dwarf : dwarves) {
                    boolean éElfoNoturno = elfoQueVaiAtacar instanceof ElfoNoturno;

                    if (éElfoNoturno) {
                        boolean devePularParaOProximo = qtdAtaquesFeitosPorNoturnos >= limiteAtaquesElfosNoturnos;
                        if (devePularParaOProximo) {
                            continue;
                        }
                        qtdAtaquesFeitosPorNoturnos++;
                    }

                    ordemDoUltimoAtaque.add(elfoQueVaiAtacar);
                    elfoQueVaiAtacar.atirarFlecha(dwarf);
                }
            }
        }
    }
}