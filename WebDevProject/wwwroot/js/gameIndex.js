'use strict';

import { GameRepository } from "./GameRepository.js";

const gameRepo = new GameRepository("https://localhost:7074/api/game");

const tableBody = document.querySelector("#tbodyGameTable");

await populateGames();

function AddGameToTable(tbody, game) {
    const tr = document.createElement("tr");
    tbody.appendChild(tr); 
    Object.keys(game).forEach(key => {
        console.log(game[key]);
        if (key != "id" && key != "genre") {
            const td = document.createElement("td");
            td.textContent = game[key];
            tr.appendChild(td);
        }
        if (key == "genre") {
            const td = document.createElement("td");
            const genres = game[key];
            const genreString = genres.join(", ");
            td.textContent = genreString;
            tr.appendChild(td);
        }
    });
    // Initialize buttons for each game
    const purchaseLink = createLink("Purchase", `${game["id"]}`, "info");
    const deleteLink = createLink("Delete", `${game["id"]}`, "danger");

    // Add an event listener for each button
    deleteLink.addEventListener("click", async (e) => {
        e.preventDefault();
        await gameRepo.Delete(game["id"]);
        tr.remove();
    });

    purchaseLink.addEventListener("click", async (e) => {
        e.preventDefault();
        await gameRepo.CreateUserGame(game["id"]);
    });

    const td = document.createElement("td");
    td.appendChild(editLink);
    td.appendChild(detailsLink);
    td.appendChild(deleteLink);
    tr.appendChild(td);
}

function createLink(text, data, btnType) {
    const link = document.createElement("a");
    link.textContent = text;
    link.dataset.id = data;
    link.className = `btn btn-${btnType} mx-1`;
    return link;
}

async function populateGames() {
    try {
        const games = await gameRepo.ReadAll();
        console.log(games);
        for (let i = 0; i < games.length; i++) {
            AddGameToTable(tableBody, games[i]);
        }
    }
    catch (e) {
        console.log(e);
    }
}