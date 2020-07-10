import api from '../../Service/api';


export default class ForgotPasswordService {

    recuperarSenha = async (email) => {
        let data = {
            "email": email
        }
        const resultApi = await api.post("/v1/user/RecoveryPassword", data)
        return resultApi;
    }
}