import api from '../../Service/api';


export default class LoginService {
    login = async (user, password) => {
        let data = {
            "userName": user,
            "password": password
        }
        const resultApi = await api.post("/v1/auth", data)
        return resultApi;
    }

    recuperarSenha = async (email) => {
        let data = {
            "email": email
        }
        const resultApi = await api.post("/v1/user/RecoveryPassword", data)
        return resultApi;
    }
}