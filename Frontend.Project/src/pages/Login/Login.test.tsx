import React, { PropsWithChildren } from 'react';
import { render, screen, fireEvent, act, waitFor } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect'; // for matchers like .toBeInTheDocument
import { useLoginMutation } from '../../services/authServices';
import Login from '.';
import { BrowserRouter as Router } from 'react-router-dom';

const mockData = {
  userName: 'dharamvir@example.com',
  password: 'Nokia@123',
}
// Mock the login mutation hook
jest.mock('../../services/authServices', () => ({
  useLoginMutation: jest.fn(),
}));

const mockLoginUser = jest.fn();

beforeEach(() => {
  (useLoginMutation as jest.Mock).mockReturnValue([mockLoginUser]);
});

describe('Login form', () => {
  test('renders Login component', () => {
    render(
      <Router>
        <Login />
      </Router>
    );

    expect(screen.getByText(/User Login/i)).toBeInTheDocument();
    expect(screen.getByText(/User Name/i)).toBeInTheDocument();
    expect(screen.getByText(/Password/i)).toBeInTheDocument();
    expect(screen.getByText(/Sign in/i)).toBeInTheDocument();
    expect(screen.getByText(/New User/i)).toBeInTheDocument();
  });
  it('submits the form with correct data', async () => {
    mockLoginUser.mockResolvedValue({ data: 'Login successful!' });
    const { getByTestId } = render(
      <Router>
        <Login />
      </Router>
    );

    fireEvent.change(getByTestId("userName"), {
      target: { value: mockData?.userName },
    });
    fireEvent.change(getByTestId("password"), {
      target: { value: mockData?.password },
    });
    await act(async () => {
      fireEvent.click(getByTestId('sign-in'));
    })

    await waitFor(() => {
      expect(mockLoginUser).toHaveBeenCalledWith(mockData);
      expect(screen.getByText(/LoggedIn Successfully/i)).toBeInTheDocument();
    });
  });

});
