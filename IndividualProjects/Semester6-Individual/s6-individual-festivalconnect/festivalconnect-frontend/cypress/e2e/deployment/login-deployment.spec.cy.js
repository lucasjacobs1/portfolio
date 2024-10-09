describe('Login Input Fields', () => {
    beforeEach(() => {
      cy.visit('http://4.182.106.183/'); // Assuming '/login' is the URL for the Login page
    });
  
    it('displays error message if email field is empty', () => {
      cy.get('#password').type('password123'); // Fill in only the password field
      cy.get('button').click()
      cy.get('#error').should('contain', 'Please fill out all fields.'); // Check for error message
    });
  
    it('displays error message for invalid email format', () => {
      cy.get('#email').type('invalidemail'); // Fill in an invalid email format
      cy.get('#password').type('password123'); // Fill in the password field
      cy.get('button').click()
      cy.get('#error').should('contain', 'Please enter a valid email.'); // Check for error message
    });

    it('successfully logs in with valid credentials', () => {
    
      // Fill in the login form
      cy.get('#email').type('test@example.com'); // Fill in a valid email
      cy.get('#password').type('password123'); // Fill in a valid password
      cy.get('button').click();
      // Check if user is redirected after successful login (assuming '/')
      cy.url().should('include', '/');
  });

});
