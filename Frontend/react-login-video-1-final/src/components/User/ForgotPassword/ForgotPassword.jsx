import React, { useState, useContext } from 'react';
import { useHistory } from 'react-router-dom';
import StoreContext from 'components/Store/Context';
import UIButton from 'components/UI/Button/Button';
import logo from './logot.png';
import './ForgotPassword.css';
import ForgotPasswordService from 'pages/ForgotPassword/Service';

const service = new ForgotPasswordService();

function initialState() {
    return { email: '' };
}

async function forgotPassword(email) {
    const { status } = await service.recuperarSenha(email);
    if (status === 200) {
        return { error: null }
    }
    return { error: 'Erro ao recuperar senha, contate o suporte' }
}

const UserForgotPassword = () => {
    const [values, setValues] = useState(initialState);
    const [error, setError] = useState(null);
    const [sucess, setSucess] = useState(false);
    const history = useHistory();

    function onChange(event) {

        const { value, name } = event.target;

        setValues({
            ...values,
            [name]: value
        });
    }

    async function onSubmit(event) {
        event.preventDefault();
        const { error } = await forgotPassword(values.email);
        setError(error);

        if (!error)
            setSucess(true);

        setValues(initialState);
    }

    return (
        <div className="user-login">
            <img src={logo} className="logo" alt="logo" />
            <form onSubmit={onSubmit}>
                <div className="user-login__form-control">
                    <label htmlFor="email"></label>
                    <input
                        id="email"
                        type="text"
                        name="email"
                        onChange={onChange}
                        value={values.email}
                        placeholder=" Informe seu e-mail "
                    />
                </div>
                <UIButton
                    type="submit"
                    theme="contained-green"
                    className="user-login__submit-button"
                    rounded
                >
                    Receber nova senha
                </UIButton>
                <div className="containerRegister">
                    <a className="comeBack" onClick={() => history.push('/login')}>Voltar</a>
                </div>
                {error && (
                    <div className="user-login__error">{error}</div>
                )}
                {sucess && (
                    <div className="user-login__sucess">Enviamos sua nova senha para o seu e-mail. Confirme sua caixa de spam.</div>
                )}
            </form>
        </div>
    );
};

export default UserForgotPassword;
