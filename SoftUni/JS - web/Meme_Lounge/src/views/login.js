import { html } from "../lib.js";

import { login } from "../api/users.js";
import { notify } from "../notify.js";

const loginTemplate = (onSubmit) => html`
  <!-- Login Page ( Only for guest users ) -->
  <section id="login">
    <form @submit=${onSubmit} id="login-form">
      <div class="container">
        <h1>Login</h1>
        <label for="email">Email</label>
        <input id="email" placeholder="Enter Email" name="email" type="text" />
        <label for="password">Password</label>
        <input
          id="password"
          type="password"
          placeholder="Enter Password"
          name="password"
        />
        <input type="submit" class="registerbtn button" value="Login" />
        <div class="container signin">
          <p>Dont have an account?<a href="/register">Sign up</a>.</p>
        </div>
      </div>
    </form>
  </section>
`;

export async function loginView(ctx) {
  ctx.render(loginTemplate(onSubmit));

  async function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(event.target);

    const email = formData.get("email");
    const password = formData.get("password");

    if (!email || !password) {
      notify("All fields are required!");
      return;
    }

    await login(email, password);
    ctx.updateNav();
    ctx.page.redirect("/memes");
  }
}
