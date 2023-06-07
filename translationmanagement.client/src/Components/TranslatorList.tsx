import { Box, Typography } from '@mui/material'
import Translator from '../Translator'
import TranslatorItem from './TranslatorItem'
import { useEffect } from 'react'

export interface TranslatorListProps {
    translators: Translator[];
}

const TranslatorList = ({ translators }: TranslatorListProps) => {
    useEffect(() => {
        console.log('just demonstrate that I know how to use it lol.')
        return () => {
            console.log('aaand unmounting.')
        };
    }, [])

    return (
        <Box style={{ marginTop: '1em' }}>
            {!translators || translators.length < 1 && <Typography variant="caption" gutterBottom>No Data!</Typography>}

            {translators && translators.map((translator: Translator, i: number) =>
                <TranslatorItem key={i} translator={translator} />
            )}
        </Box>)
}

export default TranslatorList