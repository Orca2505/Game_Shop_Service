'use strict';

export class GameRepository {
    #baseAddress;
    constructor(baseAddress) {
        this.#baseAddress = baseAddress;
    }

    async ReadAll() {
        const address = `${this.#baseAddress}/all`;
        const response = await fetch(address);

        if (!response.ok) {
            throw new Error("There was an HTTP error getting the game data.");
        }
        return await response.json();
    }

    async Create(formdata) {
        const address = `${this.#baseAddress}/create`;
        const response = await fetch(address, {
            method: "post",
            body: formdata
        });
        if (!response.ok) {
            throw new Error("Problem posting the game data.");
        }
        return response;
    }

    async Delete(id) {
        const address = `${this.#baseAddress}/delete/${id}`
        const response = await fetch(address, { method: "DELETE" });
    }
}