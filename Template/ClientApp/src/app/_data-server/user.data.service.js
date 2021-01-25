"use strict";
//contem informações que faz comunicação com banco
Object.defineProperty(exports, "__esModule", { value: true });
exports.UserDataService = void 0;
var UserDataService = /** @class */ (function () {
    function UserDataService(http) {
        this.http = http;
        this.module = '/api/users'; //modelos internos utilizaram esse modulo
        //comandos de comunicação com o banco
    }
    UserDataService.prototype.get = function () {
        return this.http.get(this.module);
    };
    return UserDataService;
}());
exports.UserDataService = UserDataService;
//# sourceMappingURL=user.data.service.js.map