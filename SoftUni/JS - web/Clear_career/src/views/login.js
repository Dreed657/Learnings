import { html } from "../lib.js";

import { login } from "../api/users.js";

const template = (onSubmit) => html`
  <!-- Login Page (Only for Guest users) -->
  <section id="login">
    <div class="form">
      <h2>Login</h2>
      <form @submit=${onSubmit} class="login-form">
        <input type="text" name="email" id="email" placeholder="email" />
        <input
          type="password"
          name="password"
          id="password"
          placeholder="password"
        />
        <button type="submit">login</button>
        <p class="message">
          Not registered? <a href="/register">Create an account</a>
        </p>
      </form>
    </div>
  </section>
`;

export async function loginView(ctx) {
  ctx.render(template(onSubmit));

  async function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(event.target);

    const email = formData.get("email");
    const password = formData.get("password");

    if (!email || !password) {
      alert("All fields are required!");
      return;
    }

    await login(email, password);
    ctx.updateNav();
    ctx.page.redirect("/dashboard");
  }
}
