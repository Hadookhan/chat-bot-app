import openai
import os

openai.api_key = os.environ["OPENAI_API_KEY"]

def get_llm_reply(messages):
    completion = openai.ChatCompletion.create(
        model="gpt-4.1-mini",
        messages=messages
    )
    return completion.choices[0].message["content"]