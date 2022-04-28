
this.onload = function(){
    const BASE_URL = "http://localhost:5206/api/Esercizi/";
    let btnSearch = document.querySelector("#btnSearch");
    let selMuscoli = document.querySelector("#selMuscolo");
    let btnRandom = document.querySelector("#btnRandom");
    
    fetch(BASE_URL + "Muscoli").then(x => x.json())
    .then(response => {
        btnSearch.disabled = false;
        btnRandom.disabled = false;


        while(selMuscoli.hasChildNodes()) selMuscoli.removeChild(selMuscoli.lastChild)
        for(let i = 0; i < response.length; i++) {
            let option = document.createElement("option");
            option.value = response[i]["muscoloID"];
            option.innerHTML = response[i]["descrizione"];
            selMuscoli.appendChild(option);            
        }

        btnSearch.addEventListener("click", async () => {
            let muscoloID = selMuscoli.value;
            let collection = await fetch(BASE_URL + muscoloID).then(x => x.json());
            let resultContainer = document.querySelector(".result-container");
            MostraCardsAllenamento(collection, resultContainer);
            resultContainer.scrollIntoView();
        });

        btnRandom.addEventListener("click", async () => {
            let element = await fetch(BASE_URL + "Random").then(x => x.json());
            let resultContainer = document.querySelector(".result-container");
            MostraCardsAllenamento([element], resultContainer);
            resultContainer.scrollIntoView();


        });

    })
    .catch(x => {
        btnSearch.disabled = true;
        btnRandom.disabled = true;
    });
};


function MostraCardsAllenamento(collection, div) {
    while(div.hasChildNodes()) div.removeChild(div.lastChild);


    div.style.display = "flex";
    const EMBED_VIDEO_WIDTH = 320;
    const EMBED_VIDEO_HEIGHT = 518;

    for(let i = 0; i < collection.length; i++) {
        let cardContainer = document.createElement("div");
        cardContainer.classList.add("card-container");
        
        let infoContainer = document.createElement("div");
        infoContainer.classList.add("info-container");

        infoContainer.appendChild(GetTitleContentDiv("Nome dell'esercizio", collection[i]["nomeEsercizio"]));
        infoContainer.appendChild(GetTitleContentDiv("Numero di serie", collection[i]["numeroSerie"]));
        infoContainer.appendChild(GetTitleContentDiv("Numero di ripetizioni", collection[i]["numeroRipetizioni"]));
        infoContainer.appendChild(GetTitleContentDiv("Secondi di recupero", collection[i]["secondiRecupero"]));
        infoContainer.appendChild(GetTitleContentDiv("Muscolo interessato", collection[i]["muscolo"]));
        infoContainer.appendChild(GetDescriptionDiv("Descrizione dell'esercizio", collection[i]["descrizione"]));
        cardContainer.appendChild(infoContainer);
        
        let videoContainer = document.createElement("div");
        videoContainer.classList.add("video-container");

        let iframe = document.createElement("iframe");
        iframe.src = collection[i]["videoURL"] + "?mute=1&autoplay=1&loop=1";
        iframe.width = EMBED_VIDEO_WIDTH + "px";
        iframe.height = EMBED_VIDEO_HEIGHT + "px";
        iframe.title = "Video " + collection[i]["nomeEsercizio"];
        iframe.allow = "accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture";
        iframe.allowFullscreen = true;
        iframe.frameBorder = 0;

        videoContainer.appendChild(iframe);

        cardContainer.appendChild(videoContainer);

        div.appendChild(cardContainer);
    }    
}


function GetTitleContentDiv(title, content) {
    let container = document.createElement("div");
    container.classList.add("title-content-container");

    let titleDiv = document.createElement("span");
    titleDiv.classList.add("title-content-title");
    titleDiv.innerText = title;
    container.appendChild(titleDiv);

    let contentDiv = document.createElement("span");
    contentDiv.classList.add("title-content-content");
    contentDiv.innerText = content;
    container.appendChild(contentDiv);

    return container;
}


function GetDescriptionDiv(title, description) {
    
    
    let details = document.createElement("details");
    details.classList.add("personalized-details");
    details.innerHTML = `<summary>${title}</summary>${description}`;

    return details;
}
