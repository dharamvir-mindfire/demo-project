// Home.test.js
import React from 'react';
import Home from './';
import { connect } from 'react-redux';
import { render } from '@testing-library/react';
import { useGetPersonsQuery } from '../../services/empServices';

jest.mock('react-redux');

// Mock the home query hook
jest.mock('../../services/empServices', () => ({
    useGetPersonsQuery: jest.fn(),
}));

const mockGetPersons = jest.fn();

beforeEach(() => {
    (useGetPersonsQuery as jest.Mock).mockReturnValue([mockGetPersons]);
});

describe('Home Component', () => {
    it('should call mapDispatchToProps and mapStateToProps correctly', () => {
        const mapStateToProps = jest.fn();
        const mapDispatchToProps = jest.fn().mockReturnValue({ logout: jest.fn() });

        (connect as jest.Mock<any, any, any>).mockImplementation((mstp, mdtp) => (Component) => {
            const props = { ...mstp(), ...mdtp(jest.fn()) };
            return (additionalProps) => <Component {...props} {...additionalProps} />;
        });

        const ConnectedComponent = connect(mapStateToProps, mapDispatchToProps)(Home);

        const wrapper = render(<ConnectedComponent />);
        const { getByText } = wrapper
        expect(wrapper).toBeTruthy();

        expect(connect).toHaveBeenCalledWith(mapStateToProps, mapDispatchToProps);
    });
});
