window.addEventListener('load',getData('http://localhost:5064/catalog', inicializarCursos));
window.addEventListener('load',getData('http://localhost:5064/maisvendidos', MaisVendidos));


const tBody = document.getElementById('corpoCarrinho');
const tFav = document.getElementById('corpoFavorito');
const tVendido = document.getElementById('maisVendidos');
const subtotal = document.querySelector(".subtotalc");




function getData(url, fn) {
    let xhr = new XMLHttpRequest();
    if (!('withCredentials' in xhr)) xhr = new XDomainRequest(); 
    xhr.open('GET', url);
    xhr.onload = fn;
    xhr.send();
    return xhr;
  }
  
  function saveData(url, fn) {
    let xhr = new XMLHttpRequest();
    if (!('withCredentials' in xhr)) xhr = new XDomainRequest(); 
    xhr.open('POST', url);
    xhr.setRequestHeader('Content-type', 'application/json')
    xhr.send(fn());
    
    xhr.onload = function() {
      return xhr.responseText;
    }				
  }


let data = [];
  
function inicializarCursos(request) { //adiciona ao site cursos dinamicamente

    let response = request.currentTarget.response || request.target.responseText;
    let cursos = JSON.parse(response);
    data.push(cursos)
        
    let containerCursos = document.getElementById('card');
    cursos.some((val) => {
        containerCursos.innerHTML += `
        <div id="lista-cursos" class="info-card">
        <img src="img/`+ val.nomeimagem + `" class="imagen-curso u-full-width">
        <h4>`+ val.titulo + `</h4>
        <p>`+ val.autor + `</p>
        <img src="img/estrelas.png">
        <p>Preço<span class="u-pull-right ">Oferta</span></p>
        <p class="preco">€ `+ val.preco + `<span class="u-pull-right ">€ ` + val.promocao + `</span></p>
        <a href="#"><img src="img/heart.png"  id="img-carrinho" onclick="adicionar_favorito(`+ val.isbn + `)"></a>
        <a href="#" class="u-full-width button-primary button input adicionar-carrinho"
        data-id="1" key="${val.isbn}" onclick="adicionar_carrinho(${val.isbn});" id="incart">Adicionar ao Carrinho</a>
        </div>
        `;
    })
}

let carrinho = JSON.parse(localStorage.getItem('itens')) || []; //recebe cursos escolhidos

atualizarcarrinho();


function adicionar_carrinho(isbn) { //adiciona itens ao carrinho
    if (carrinho.some((item) => item.isbn === isbn)) {
        mudarQuantidade("plus", isbn);
    } else {
        const item = data[0].find((cursoc) => cursoc.isbn === isbn);
        carrinho.push({ ...item, qtd: 1, });
        
    }
    localStorage.setItem('itens', JSON.stringify(carrinho));
    atualizarcarrinho();
}

function conteudoCarrinho() { //cria itens no carrinho

    if (carrinho != null) {
        let tr = '';
        carrinho.map(item => {
            tr += `
                <tr>
                <td><img src="img/${item.nomeimagem}" width=100></td>
                <td>${item.titulo}</td>
                <td>€${item.preco}</td>
                <td>${item.qtd} </td>
                </tr>
                <div class="unidades">
                <div class="btn minus" onclick="mudarQuantidade('minus', ${item.isbn})">-</div>
                <div class="btn plus" onclick="mudarQuantidade('plus', ${item.isbn})">+</div>           
                </div>
    `
    })
        tBody.innerHTML = tr;
    }
}

function limpa() { //esvazia o carrinho
    const arr = JSON.parse(localStorage.getItem('itens'));
    localStorage.clear();
    carrinho.length = 0;
    if (arr != null) {
        let tr = '';
        arr.map(item => {
            tr += ` `
        })
        tBody.innerHTML = tr;
    }
    carrinhoSubtotal();
}





let favorito = [];//recebe cursos favoritos

function adicionar_favorito(isbn) { //adiciona itens ao array favoritos
    let itemf=[];
    itemf = data[0].find((curso) => curso.isbn === isbn);
    
    if (favorito.some((item) => item.isbn === isbn)) {
        alert("Curso já marcado como favorito!!!")
    } else {
        const item = data[0].find((cursoc) => cursoc.isbn === isbn);
        favorito.push(item);
    }

    localStorage.setItem('favs', JSON.stringify(favorito));
    addFavorito();
}

function addFavorito() { //adiciona item ao favorito com botão para adicionar ao carrinho
    const arrf = JSON.parse(localStorage.getItem('favs'));

    if (arrf != null) {
        let trf = '';
        arrf.map(itemf => {
            trf += ` 
            <div class="curso-single">
            <img src="img/`+ itemf.nomeimagem + `" class="imagen-curso u-full-width">
            <h4>`+ itemf.titulo + `</h4>
            <p>`+ itemf.autor + `</p>
            <p class="preco">Preço<span class="u-pull-right ">Oferta</span></p>
            <h4 class="preco">€  `+ itemf.preco + `<span class="u-pull-right ">€  ` + itemf.promocao + `</span></h4>
            <a href="#" class="u-full-width button-primary button input adicionar-carrinho"
            data-id="1" key="`+ itemf.isbn + `" onclick="adicionar_carrinho(` + itemf.isbn + `);" id="incart">Adicionar ao Carrinho</a>
            </div>
            `})
        tFav.innerHTML = trf;
    }
}

function limpaf() { //esvazia o carrinho
    const arrf = JSON.parse(localStorage.getItem('itens'));
    favorito.length = 0;
    if (arrf != null) {
        let trf = '';
        arrf.map(item => {
            trf += ` `
        })
        tFav.innerHTML = trf;
    }


}


function mudarQuantidade(action, isbn) { //muda quantidade de itens no carrinho
    carrinho = carrinho.map((item) => {
        let qtd = item.qtd;

        if (item.isbn === isbn) {
            if (action === "minus") {
                if(item.qtd<=0){
                    item.qtd=item.qtd
                }else{
                qtd--;
                }
            } else if (action === "plus") {
                qtd++;
            }
        }

        return {
            ...item,
            qtd,
        };
    });

    atualizarcarrinho();
}

function atualizarcarrinho() {
    conteudoCarrinho();
    carrinhoSubtotal();
    
    localStorage.setItem('itens', JSON.stringify(carrinho));
}

function carrinhoSubtotal() { //renderiza e calcula valor no carrinho
    let totalPreco = 0,
        totalItems = 0;

    carrinho.forEach((item) => {
        totalPreco += item.promocao * item.qtd;
        totalItems += item.qtd;

    });
    subtotal.innerHTML = `Subtotal (${totalItems} items): € ${totalPreco.toFixed(2)}`;

}



function checkout() { //esvazia o carrinho e adiciona ao mais vendidos

    let listData = new Object();
    listData.isbn = carrinho.map(function(e) { return e.isbn; });

    limpa();

    return JSON.stringify(listData);
}





function MaisVendidos(request){
    let response = request.currentTarget.response || request.target.responseText;
    let mv = JSON.parse(response);
    let arrv = [];
    arrv.push(mv[0]);

    if (arrv != null) {
        let trv = '';
        arrv.find(itemv => {
            trv += ` 
            <div class="curso-single">
            <img src="img/`+ itemv.nomeimagem + `" class="imagen-curso u-full-width">
            <h4>`+ itemv.titulo + `</h4>
            <p>`+ itemv.autor + `</p>
            <p class="preco">Preço<span class="u-pull-right ">Oferta</span></p>
            <h4 class="preco">€  `+ itemv.preco + `<span class="u-pull-right ">€  ` + itemv.promocao + `</span></h4>
            <a href="#" class="u-full-width button-primary button input adicionar-carrinho"
            data-id="1" key="`+ itemv.isbn + `" onclick="adicionar_carrinho(` + itemv.isbn + `);" id="incart">Adicionar ao Carrinho</a>
            </div>
            `})
        tVendido.innerHTML = trv;
    }
}


