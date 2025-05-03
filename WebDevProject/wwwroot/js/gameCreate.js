'use strict';

import { GameRepository } from "./GameRepository.js";

const gameRepo = new GameRepository("https://localhost:7074/api/game");

const formCreate = document.querySelector("#formgameCreate");

formCreate.addEventListener("submit", async (e) => {
    e.preventDefault();
    const formData = new FormData(formCreate);
    for (const [key, value] of formData.entries()) {
        console.log(key, value);
    }
    try {
        const result = await gameRepo.Create(formData);
        console.log(result);
        window.location.replace("index");
    }
    catch (e) {
        console.log(e);
    }
});