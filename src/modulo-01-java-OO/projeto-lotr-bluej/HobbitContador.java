import java.util.ArrayList;

public class HobbitContador {
    public int calcularDiferenca(ArrayList<ArrayList<Integer>> pares) {
        int somaProdutos = 0, somaMmc = 0;

        for (ArrayList<Integer> par : pares) {
            int a = par.get(0), b = par.get(1);
            somaProdutos += a * b;
            somaMmc += new CalculadorMmc(a, b).calcular();
        }

        return somaProdutos - somaMmc;
    }

    // o exercício pedia APENAS o maior múltiplo de 3, então o mais correto é utilizar break invés de continue
    // melhoria: como queremos o maior, vale mais a pena começar a procurá-lo do fim para o início.
    // obs: não era necessário o ArrayList, o Hobbit estava um pouco louco quando escreveu o código.
    public int obterMaiorMultiploDeTresAte(int numero) {

        int maior = 0;

        for (int i = numero; i >= 0; i--) {
            if (i % 3 == 0) {
                maior = i;
                break;
            }
        }

        return maior;
    }

    private class CalculadorMmc {
        private int a, b;
        private CalculadorMmc(int a, int b) {
            this.a = a;
            this.b = b;
        }

        // https://en.wikipedia.org/wiki/Least_common_multiple
        private int calcular() {
            boolean temZero = a == 0 || b == 0;
            return temZero ? 0 : a * b / mdc(a,b);
        }

        // https://en.wikipedia.org/wiki/Greatest_common_divisor
        private int mdc(int a, int b) {
            while (b != 0) {
                int troca = b;
                b = a % b;
                a = troca;
            }
            return a;
        }
    }
}