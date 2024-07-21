/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Pages/**/*.{html,cshtml}',
    './wwwroot/css/**/*.css',
  ],
  theme: {
    extend: {
      fontFamily: {
        'segoe': ['"Segoe UI"', 'system-ui', '-apple-system', 'Roboto', 'Arial', 'sans-serif']
      },
      plugins: [],
    }
  }
}
