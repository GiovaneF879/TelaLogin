import React, { useState, useContext } from 'react';
import { useHistory } from 'react-router-dom';
import StoreContext from 'components/Store/Context';
import UIButton from 'components/UI/Button/Button';
import logo from './logot.png';
import './Registerr.css';
import LoginService from 'pages/Login/Service';

const service = new LoginService();

function initialState() {
  return { user: '', password: '' };
}


const UserLogin = () => {
  //const [error, setError] = useState(null);

  async function onSubmit(event) {

  }

  return (
    <div className="user-login">
      <form onSubmit={onSubmit}>
        <div className="user-login__form-control">
          <label htmlFor="user"></label>
          <input
            id="user"
            type="text"
            name="user"
            // onChange={onChange}
            value={values.user}
            placeholder=" Usuário "
          />
        </div>
        <div className="user-login__form-control">
          <label htmlFor="password"></label>
          <input
            id="password"
            type="password"
            name="password"
            onChange={onChange}
            value={values.password}
            placeholder=" Senha "
          />
        </div>
        {error && (
          <div className="user-login__error">{error}</div>
        )}
        <UIButton
          type="submit"
          theme="contained-green"
          className="user-login__submit-button"
          rounded
        >
          Entrar
        </UIButton>
        <a onClick={() => recuperarSenha(values.user)}>Alterar senha</a>
      </form>
    </div>
  );
};

export default UserLogin;
