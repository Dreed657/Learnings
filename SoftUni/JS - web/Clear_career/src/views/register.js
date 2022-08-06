import { html } from "../lib.js";

import { register } from "../api/users.js";

const template = (onSubmit) => html`
  <!-- Register Page (Only for Guest users) -->
  <section id="register">
    <div class="form">
      <h2>Register</h2>
      <form @submit=${onSubmit} class="login-form">
        <input
          type="text"
          name="email"
          id="register-email"
          placeholder="email"
        />
        <input
          type="password"
          name="password"
          id="register-password"
          placeholder="password"
        />
        <input
          type="password"
          name="re-password"
          id="repeat-password"
          placeholder="repeat password"
        />
        <button type="submit">register</button>
        <p class="message">Already registered? <a href="#">Login</a></p>
      </form>
    </div>
  </section>
`;

export async function registerView(ctx) {
  ctx.render(template(onSubmit));

  async function onSubmit(event) {
    event.preventDefault();

    const formData = new FormData(event.target);

    const email = formData.get("email");
    const password = formData.get("password");
    const repassword = formData.get("re-password");

    if (!email || !password || !repassword) {
      alert("All fields are required!");
      return;
    }

    if (password !== repassword) {
      alert("Both passwords should match!");
      return;
    }

    await register(email, password);
    ctx.updateNav();
    ctx.page.redirect("/dashboard");
  }
}
