import { Card, CardContent, Typography } from '@mui/material'
import Translator from '../Translator'

export interface TranslatorProps {
    translator: Translator;
}

const TranslatorItem = ({ translator }: TranslatorProps) => {
    const { name } = translator
    return (
        <Card style={{ marginTop: '5px' }}>
            <CardContent>
                <Typography gutterBottom variant="h5" component="div">
                    {name}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    {name} is a translator with {translator.status} status. Hourly rate of {name} is {translator.hourlyRate} USD.
                </Typography>
            </CardContent>
        </Card>
    )
}

export default TranslatorItem